using Microsoft.Maui.Controls;

namespace Notes;

public partial class MainPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public MainPage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
        {
            Editor.Text = File.ReadAllText(_fileName);
        }

        SaveButton.Clicked += OnSaveButtonClicked;

        DeleteButton.Clicked += OnDeleteButtonClicked;
    }

    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, Editor.Text);
    }

    void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        Editor.Text = string.Empty;
    }
}

