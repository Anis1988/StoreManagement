

const firstName = localStorage.getItem("custf");
const lastName = localStorage.getItem("custl");
const store = localStorage.getItem("store");
let total = 0;
var formatter = new Intl.NumberFormat('en-US',
    {
        style: 'currency',
        currency: 'USD'
    });
console.log(12);
console.log(firstName);
console.log(lastName);
console.log(store);

fetch(`https://localhost:44369/api/order/${store}/${firstName}`)
    .then(res => res.json()).then(res => {
        document.body.innerHTML += "";
        console.log(res);
        res.forEach(p => {
            fetch(`https://localhost:44369/api/product/${p.productId}`)
                .then(res => res.json())
                .then(res => {

                    document.body.innerHTML += `<ul> <li> ${res.name}  ${formatter.format(res.unitPrice)}</li></ul>`;
                    total += res.unitPrice;
                    document.body.innerHTML += `<h4> Your Total is : ${formatter.format(total)}</h4>`;
                });

        });
    }).catch(err => {
        console.log("ERROR");
    });
    


document.body.innerHTML = `You order for ${firstName} ${lastName} : `;






