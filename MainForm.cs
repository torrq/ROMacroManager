using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace ROMacroManager
{
    public partial class MainForm : Form
    {
        private const string REGISTRY_PATH = @"SOFTWARE\WOW6432Node\Gravity Soft\Ragnarok\ShortCutList";
        private const string PROFILES_FILE = "profiles.json";

        private List<ShortcutProfile> profiles = new List<ShortcutProfile>();
        private ShortcutProfile currentProfile = null;
        private TextBox[] shortcutTextBoxes = new TextBox[10];

        public MainForm()
        {
            InitializeComponent();
            CreateShortcutControls();
            LoadProfiles();
            LoadCurrentRegistrySettings();
        }

        private void CreateShortcutControls()
        {
            // Create shortcut entries after InitializeComponent
            for (int i = 0; i < 10; i++)
            {
                // Key label (Alt + number)
                var lblKey = new System.Windows.Forms.Label();
                lblKey.Text = $"Alt + {(i + 1) % 10}";
                lblKey.Location = new Point(20, 64 + (i * 25));
                lblKey.Size = new Size(50, 20);
                lblKey.TextAlign = ContentAlignment.MiddleLeft;
                this.Controls.Add(lblKey);

                // Command textbox
                var txtCommand = new TextBox();
                txtCommand.Name = $"txtShortcut{i}";
                txtCommand.Location = new Point(75, 63 + (i * 25));
                txtCommand.Size = new Size(370, 20);
                txtCommand.TextChanged += TxtCommand_TextChanged;
                shortcutTextBoxes[i] = txtCommand;
                this.Controls.Add(txtCommand);
            }
        }

        private void LoadProfiles()
        {
            try
            {
                if (File.Exists(PROFILES_FILE))
                {
                    string json = File.ReadAllText(PROFILES_FILE);
                    profiles = JsonConvert.DeserializeObject<List<ShortcutProfile>>(json) ?? new List<ShortcutProfile>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profiles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            RefreshProfileComboBox();
        }

        private void SaveProfiles()
        {
            try
            {
                string json = JsonConvert.SerializeObject(profiles, Formatting.Indented);
                File.WriteAllText(PROFILES_FILE, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving profiles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshProfileComboBox()
        {
            cmbProfiles.Items.Clear();

            foreach (var profile in profiles)
            {
                cmbProfiles.Items.Add(profile.Name);
            }

            if (currentProfile != null && profiles.Contains(currentProfile))
            {
                cmbProfiles.SelectedItem = currentProfile.Name;
            }
        }

        private void LoadCurrentRegistrySettings()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(REGISTRY_PATH))
                {
                    if (key != null)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            string value = key.GetValue(i.ToString()) as string ?? "";
                            if (shortcutTextBoxes[i] != null)
                                shortcutTextBoxes[i].Text = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading from registry: {ex.Message}\n\nMake sure to run as administrator.",
                    "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplySettingsToRegistry()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.CreateSubKey(REGISTRY_PATH))
                {
                    if (key != null)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (shortcutTextBoxes[i] != null)
                                key.SetValue(i.ToString(), shortcutTextBoxes[i].Text);
                        }
                    }
                }
                MessageBox.Show("Settings applied to game successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to registry: {ex.Message}\n\nMake sure to run as administrator.",
                    "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo.SelectedIndex >= 0)
            {
                currentProfile = profiles[combo.SelectedIndex];
                LoadProfileToUI(currentProfile);
            }
        }

        private void LoadProfileToUI(ShortcutProfile profile)
        {
            for (int i = 0; i < 10 && i < profile.Shortcuts.Count; i++)
            {
                if (shortcutTextBoxes[i] != null)
                    shortcutTextBoxes[i].Text = profile.Shortcuts[i] ?? "";
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            using (var inputForm = new InputDialog("Enter profile name:", "New Profile", "New Profile"))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string profileName = inputForm.InputText;

                    if (!string.IsNullOrWhiteSpace(profileName))
                    {
                        if (profiles.Any(p => p.Name.Equals(profileName, StringComparison.OrdinalIgnoreCase)))
                        {
                            MessageBox.Show("Profile name already exists!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var newProfile = new ShortcutProfile
                        {
                            Name = profileName,
                            Shortcuts = new List<string>(new string[10]) // Initialize with 10 empty strings
                        };

                        profiles.Add(newProfile);
                        currentProfile = newProfile;
                        SaveProfiles();
                        RefreshProfileComboBox();

                        // Clear all textboxes for new profile
                        for (int i = 0; i < 10; i++)
                        {
                            if (shortcutTextBoxes[i] != null)
                                shortcutTextBoxes[i].Text = "";
                        }
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentProfile != null)
            {
                // Update current profile with UI values
                for (int i = 0; i < 10; i++)
                {
                    if (i >= currentProfile.Shortcuts.Count)
                        currentProfile.Shortcuts.Add("");
                    if (shortcutTextBoxes[i] != null)
                        currentProfile.Shortcuts[i] = shortcutTextBoxes[i].Text;
                }

                currentProfile.LastModified = DateTime.Now;
                SaveProfiles();
                MessageBox.Show("Profile saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No profile selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (currentProfile != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete profile '{currentProfile.Name}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    profiles.Remove(currentProfile);
                    currentProfile = null;
                    SaveProfiles();
                    RefreshProfileComboBox();

                    // Clear UI
                    for (int i = 0; i < 10; i++)
                    {
                        if (shortcutTextBoxes[i] != null)
                            shortcutTextBoxes[i].Text = "";
                    }
                }
            }
        }

        private void BtnApplyToGame_Click(object sender, EventArgs e)
        {
            ApplySettingsToRegistry();
        }

        private void BtnLoadFromGame_Click(object sender, EventArgs e)
        {
            LoadCurrentRegistrySettings();
        }

        private void TxtCommand_TextChanged(object sender, EventArgs e)
        {
            // Auto-save to current profile when text changes (optional)
            // You can enable this for real-time saving or leave it for manual save
        }
    }

    [Serializable]
    public class ShortcutProfile
    {
        public string Name { get; set; }
        public List<string> Shortcuts { get; set; } = new List<string>();

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}