
var formatter = new Intl.NumberFormat('en-US',
    {
        style: 'currency',
        currency: 'USD'
    });

const  HomeScreen = {
  render: async() => {
      const response = await fetch("https://localhost:44369/api/product",
          {
              headers: {
                  "Content-Type": "application/json"
              },
          });
        if (!response || !response.ok) {
            return `<div>Error on getting the data </div>`;
        }
    const products  = await response.json();
    return `
        <ul class="products">
        ${products
          .map(
            (product) => `
            <li>
                 <div class="product">
               
                  <img src="${product.productUrl}" alt="${product.name}" />
                </a>
                <div class="product-name">
                  <span> "${product.name}" </span>
                  <div class="product-price">${formatter.format(product.unitPrice)}</div>
                </div>
              </div>
            </li>
        `
          )
          .join("\n")}
        </ul>
        `;
  },
};
export default HomeScreen;
