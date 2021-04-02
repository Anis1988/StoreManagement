
var formatter = new Intl.NumberFormat('en-US',
    {
        style: 'currency',
        currency: 'USD'
    });

export const fname = localStorage.getItem("custf");
export const lname = localStorage.getItem("custl");
 
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
     let  products = await response.json();
        return `
        <ul class="products">
        ${products
            .map((product) => 

                    ` <li>
                 <div class="product">
               
                  <img src="${product.productUrl}" alt="${product.name}" />
                
                <div class="product-name">
                  <span> ${product.name} </span>
                  <div class="product-price">${formatter.format(product.unitPrice)}</div>
                    <div class = "btnSelect">
                  <button id="btn"> ADD TO BAG </button>   
                    </div>       
                </div>

              </div>
            </li> `
                    
          )
          .join("\n")
                }
           
        `;
  },
};

const router = async () => {
    const main = document.getElementById("main-container");
    main.innerHTML = await HomeScreen.render();
    document.getElementById("name").innerHTML = `      ${localStorage.getItem("custf")}     ${localStorage.getItem("custl")}`;
    console.log(localStorage.getItem("store"));
    const storeObj = await  fetch(`https://localhost:44369/api/store/${localStorage.getItem('store')}`)
        .then(res => res.json());
    console.log(storeObj.storeId);
    main.addEventListener("click", () => {
        console.log("It's Clicked");
        const data = {
            customerId: localStorage.getItem("id"),
            storeId: storeObj.storeId,
            productId:  "F8E9DB56-AF2D-4D72-ABB0-677BB06A2A24"
        };
        console.log(data);
        fetch("https://localhost:44369/api/order", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });
    });
    
};




window.addEventListener("load", router);




//export default HomeScreen ;
