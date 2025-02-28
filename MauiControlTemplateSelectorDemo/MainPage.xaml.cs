namespace MauiControlTemplateSelectorDemo;

public class Question
{
	public string? Type { get; set; }
}

public partial class MainPage : ContentPage
{
	public List<Question> Questions { get; } =
	[
		new Question { Type = "Text" },
		new Question { Type = "Note" },
		new Question { Type = "DateTime" },
	];

	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
}
