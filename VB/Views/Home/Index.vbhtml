@ModelType CS.Model.MyViewModel
<script type="text/javascript">
    function OnFocusedRowChanged(s, e) {
        gvProducts.PerformCallback();
    }

    function OnBeginCallback(s, e) {
        e.customArgs["MasterRowKey"] = gvCategories.GetRowKey(gvCategories.GetFocusedRowIndex());
    }
    function BeforeExport(button) {
        var actionParts = $("form").attr("action").split("?MasterRowKey=");
        actionParts[1] = gvCategories.GetRowKey(gvCategories.GetFocusedRowIndex());
        $("form").attr("action", actionParts.join("?MasterRowKey="));
    }
</script>

@Using(Html.BeginForm(new With { .Controller = "Home", .Action = "ExportTo" })) 
    @Html.Partial("GridViewPartialCategories", Model.Categories)
    @<br />
    Html.Partial("GridViewPartialProducts", Model.Products)
    @<br />
    Html.DevExpress().Button(Sub(settings)
        settings.Name = "btnExport"
        settings.Text = "Export"
        settings.UseSubmitBehavior = true
        settings.ClientSideEvents.Click = "function(s, e) { BeforeExport(s); }"
    End Sub).GetHtml()
End Using