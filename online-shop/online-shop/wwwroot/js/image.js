let renderPhoto = function (productId, imgTag) {
    let request = fetch(`/api/photos/product/${productId}`);

    request
        .then(response => {
            if (response.ok) {
                response.json()
                    .then(json => {
                        let photos = json.photos;
                        let photosMedium = photos.filter(photo => photo.size === 1);
                        if (photosMedium.length > 0) {
                            imgTag.src = `/api/Photos/${photosMedium[0].id}.png`;
                        }
                    })
            }
        })
        .catch(error => {
            console.log(error);
        });
}

let productsList = document.getElementsByClassName("product");

for (let product of productsList) {
    let productId = product.getAttribute("data-product-id");
    let imgTag = product.getElementsByTagName("img")[0];
    renderPhoto(productId, imgTag);
}