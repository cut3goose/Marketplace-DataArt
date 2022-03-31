var products = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace("name"),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    remote: {
        url: "/api/products/search?query=%QUERY&PageNumber=1&PageSize=50",
        wildcard: "%QUERY",
        transform: function (response) {
            return response.pageData;
        }
    }
});
$("#product").typeahead({
    minLength: 1,
    highlight: true
}, {
    limit: 50,
    name: "products",
    display: "name",
    source: products
}).on("typeahead:select", function (e, product) {
    $("#products").append(`<li class="list-group-item">${product.name}</li>`);
    $("#product").typeahead("val", product.name);
});