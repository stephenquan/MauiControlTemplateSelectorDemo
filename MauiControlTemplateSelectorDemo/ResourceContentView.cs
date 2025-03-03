namespace MauiControlTemplateSelectorDemo;

/// <summary>
/// A ContentView that displays a ControlTemplate from a ResourceDictionary.
/// </summary>
public partial class ResourceContentView : ContentView
{
	/// <summary>
	/// Bindable property for <see cref="Key"/>.
	/// </summary>
	public static BindableProperty KeyProperty = BindableProperty.Create(nameof(Key), typeof(string), typeof(ResourceContentView), null,
		propertyChanged: (b, o, n) => ((ResourceContentView)b).RefreshControlTemplate());

	/// <summary>
	/// The key of the ControlTemplate to display.
	/// </summary>
	public string Key
	{
		get => (string)GetValue(KeyProperty);
		set => SetValue(KeyProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="Source"/>.
	/// </summary>
	public static BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ResourceDictionary), typeof(ResourceContentView), null);

	/// <summary>
	/// The ResourceDictionary to look up the ControlTemplate in.
	/// </summary>
	public ResourceDictionary Source
	{
		get => (ResourceDictionary)GetValue(SourceProperty);
		set => SetValue(SourceProperty, value);
	}

	/// <summary>
	/// A default ControlTemplate to display if the key is not found in the Source.
	/// </summary>
	public ControlTemplate? Default { get; set; }

	/// <summary>
	/// Internal method to refresh the ControlTemplate.
	/// </summary>
	void RefreshControlTemplate()
	{
		ControlTemplate = (Key is string key
			&& Source is ResourceDictionary rd
			&& rd.TryGetValue(key, out var template)
			&& template is ControlTemplate ct) ? ct : Default;
	}

	/// <summary>
	/// Initializes a new instance of <see cref="ResourceContentView"/>.
	/// </summary>
	public ResourceContentView()
	{
		RefreshControlTemplate();
	}
}
