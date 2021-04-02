

const firstName = localStorage.getItem("custf");
const lastName = localStorage.getItem("custl");
const store = localStorage.getItem("store");
console.log(12);
console.log(firstName);
console.log(lastName);
console.log(store);

fetch(`https://localhost:44369/api/order/${store}/${firstName}`)
    .then(res => res.json()).then(res => {
        res.map(o => {

        })
        document.body.innerHTML += "";

        console.log(res);
    }).catch(err => {
        console.log("ERROR");
    })


document.body.innerHTML = `You order for ${firstName} ${lastName} : `;






