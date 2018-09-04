<!DOCTYPE HTML>

<html>
<head>
    <title>@ViewBag.Title</title>
    @Html.DevExpress().GetStyleSheets( 
        new StyleSheet With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout }, 
        new StyleSheet With { .ExtensionSuite = ExtensionSuite.Editors }, 
        new StyleSheet With { .ExtensionSuite = ExtensionSuite.HtmlEditor }, 
        new StyleSheet With { .ExtensionSuite = ExtensionSuite.GridView }, 
        new StyleSheet With { .ExtensionSuite = ExtensionSuite.PivotGrid },
        new StyleSheet With { .ExtensionSuite = ExtensionSuite.Chart },
        new StyleSheet With { .ExtensionSuite = ExtensionSuite.Report } 
	) 
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    @Html.DevExpress().GetScripts( 
        new Script With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout }, 
	    new Script With { .ExtensionSuite = ExtensionSuite.HtmlEditor }, 
	    new Script With { .ExtensionSuite = ExtensionSuite.GridView }, 
	    new Script With { .ExtensionSuite = ExtensionSuite.PivotGrid },
	    new Script With { .ExtensionSuite = ExtensionSuite.Editors }, 
        new Script With { .ExtensionSuite = ExtensionSuite.Chart },
	    new Script With { .ExtensionSuite = ExtensionSuite.Report } 
    ) 
</head>

<body>
    @RenderBody()
</body>
</html>
