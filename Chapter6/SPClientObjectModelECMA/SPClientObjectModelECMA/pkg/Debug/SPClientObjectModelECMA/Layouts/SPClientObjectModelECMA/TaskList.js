function GetSiteTitle() {
    var clientContext = new SP.ClientContext.get_current();
    var web = clientContext.get_web();
    var list = web.get_lists().getByTitle("Pages");
    var camlQuery = new SP.CamlQuery();
    var q = '<View><RowLimit>5</RowLimit></View>';
    camlQuery.set_viewXml(q);
    this.listItems = list.getItems(camlQuery);
    clientContext.load(listItems, 'Include(DisplayName,Id)');
    clientContext.executeQueryAsync(Function.createDelegate(this, this.onListItemsLoadSuccess),
Function.createDelegate(this, this.onQueryFailed));
}
function onListItemsLoadSuccess(sender, args) {
    var listEnumerator = this.listItems.getEnumerator();
    //iterate though all of the items
    while (listEnumerator.moveNext()) {
        var item = listEnumerator.get_current();
        var title = item.get_displayName();
        var id = item.get_id();
        alert("List title : " + title + "; List ID : " + id);
        $('#results').append(title);
    }
}

function onQueryFailed(sender, args) {
    alert('request failed ' + args.get_message() + '\n' + args.get_stackTrace());
}