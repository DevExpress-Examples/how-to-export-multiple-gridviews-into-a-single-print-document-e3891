@Html.DevExpress().GridView(Sub(settings)
    settings.Name = "gvCategories"
    settings.CallbackRouteValues = new With { .Controller = "Home", .Action = "GridViewPartialCategories" }

    settings.KeyFieldName = "CategoryID"

    settings.Columns.Add("CategoryID")
    settings.Columns.Add("CategoryName")
    settings.Columns.Add("Description")

    settings.SettingsBehavior.AllowFocusedRow = true
    
    settings.ClientSideEvents.FocusedRowChanged = "OnFocusedRowChanged"
    
End Sub).Bind(Model).GetHtml()