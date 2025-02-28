namespace MauiControlTemplateSelectorDemo;

public partial class ResourceContentView : ContentView
{
	public static BindableProperty KeyProperty = BindableProperty.Create(nameof(Key), typeof(string), typeof(ResourceContentView), null,
		propertyChanged: (b, o, n) => ((ResourceContentView)b).RefreshControlTemplate());
	public string Key
	{
		get => (string)GetValue(KeyProperty);
		set => SetValue(KeyProperty, value);
	}

	public static BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ResourceDictionary), typeof(ResourceContentView), null);
	public ResourceDictionary Source
	{
		get => (ResourceDictionary)GetValue(SourceProperty);
		set => SetValue(SourceProperty, value);
	}

	public ControlTemplate? Default { get; set; }

	void RefreshControlTemplate()
	{
		ControlTemplate = (Key is string key
			&& Source is ResourceDictionary rd
			&& rd.TryGetValue(key, out var template)
			&& template is ControlTemplate ct) ? ct : Default;
	}

	public ResourceContentView()
	{
		RefreshControlTemplate();
	}
}
