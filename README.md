# AspNetCore.Razor.TagHelpers.L10N

AspNetCore.Razor.TagHelpers.L10N is a Localization library for AspNetCore Razor Pages.


### Installation

You should install [AspNetCore.Razor.TagHelpers.L10N with NuGet](https://www.nuget.org/packages/AspNetCore.Razor.TagHelpers.L10N/):

    Install-Package AspNetCore.Razor.TagHelpers.L10N
    
Or via the .NET Core command line interface:

    dotnet add package AspNetCore.Razor.TagHelpers.L10N

Either commands, from Package Manager Console or .NET Core CLI, will download and install AspNetCore.Razor.TagHelpers.L10N and all required dependencies.

## Import

_ViewImports.cshtml
```
@using AspNetCore.Razor.TagHelpers.L10N
@addTagHelper *, AspNetCore.Razor.TagHelpers.L10N
```

## Usage

```
<locale key="hello.world">
    Hello World
</locale>
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://github.com/MCKanpolat/AspNetCore.Razor.TagHelpers.L10N/blob/master/LICENSE)
