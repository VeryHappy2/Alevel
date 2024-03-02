class User {
    id;
    avatar;
    email;
    first_name;
    last_name;

    constructor(
        id, avatar, email, first_name, last_name) {
            this.id = id;
            this.avatar = avatar;
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
    }
}

class SingleUserResponce{
    data;

    constructor(page, per_page, total, total_pages, userData) {

        this.data = new User(
            userData.id,
            userData.avatar,
            userData.email,
            userData.first_name,
            userData.last_name
        );
    }
}

class UsersResponse {
    page;
    per_page;
    total;
    total_pages;
    data;

    constructor(
        page, per_page, total, total_pages, data) {
            this.page = page;
            this.per_page = per_page;
            this.total = total;
            this.total_pages = total_pages;
            
            const dataArray = [];

            data.forEach(element => {
                dataArray.push(
                new User(
                    element.id,
                    element.avatar,
                    element.email,
                    element.first_name,
                    element.last_name))
            });

            this.data = dataArray;
        }
};

class Color{
    id;
    name;
    color;
    pantone_value;
    last_name;

    constructor(
        id, name, color, pantone_value, last_name) {
            this.id = id;
            this.name = name;
            this.color = color;
            this.pantone_value = pantone_value;
            this.last_name = last_name;
    }
}

class ColorResponce{
    page;
    per_page;
    total;
    total_pages;
    data;

    constructor(
        page, per_page, total, total_pages, data) {
            const dataArray = [];

            data.forEach(element => {
                dataArray.push(
                new Color(
                    element.id,
                    element.name,
                    element.color,
                    element.pantone_value,
                    element.last_name))
            });

            this.data = dataArray;
        }
}



function GET(url, object) {
    const reqres = "https://reqres.in/";

    fetch(`${reqres}${url}`)
        .then(async response => {
            if(!response.ok){
                window.open('../pages/404.html', '_blank')
            }
            const bodyObject = await response.json();
            console.log(bodyObject);

            const usersResponse = new object(
                bodyObject.page,
                bodyObject.per_page,
                bodyObject.total,
                bodyObject.total_pages,
                bodyObject.data);         

            console.log('usersResponse:', usersResponse);
            if(object === UsersResponse){
                generationUsers(usersResponse)  
            }
            else{
                generationUser(usersResponse)
            }    
                     
        })
        .catch(error => console.ror('Error:' + error));  
        
}

function generationUser(object){

    let place = document.getElementById('content')
    
    var elementsToRemove = place.querySelectorAll('div');

    elementsToRemove.forEach(element => {
        element.remove();
    });
    const newCard = document.createElement('div');
    newCard.classList.add('card');
    place.appendChild(newCard);

    const newUser = document.createElement('ul')
    newUser.classList.add('list-group');
    newUser.classList.add('list-group-flush');
    
    newCard.appendChild(newUser);
    
    let userli = document.createElement('li');
    userli.classList.add('list-group-item');
    userli.textContent = 'User:' 
    newUser.appendChild(userli);

    userli.style.backgroundColor = 'rgb(247, 247, 247)'
    userli.style.textAlign = 'left';
                    
    let userid = document.createElement('li');
    userid.classList.add('list-group-item');
    userid.textContent = 'id: ' + object.data.id

    newUser.appendChild(userid);

    let avatar = document.createElement('li');
    avatar.classList.add('list-group-item');
    avatar.textContent = 'Avatar: ' + object.data.avatar;

    newUser.appendChild(avatar);

    let email = document.createElement('li');
    email.classList.add('list-group-item');
    email.textContent = 'Email: ' + object.data.email;


    newUser.appendChild(email);

    let first_name = document.createElement('li');
    first_name.classList.add('list-group-item');
    first_name.textContent = 'First name: ' + object.data.first_name;

    newUser.appendChild(first_name);

    let last_name = document.createElement('li');
    last_name.classList.add('list-group-item');
    last_name.textContent = 'Last name: ' + object.data.last_name;

    
    newUser.appendChild(last_name);

}

function generationUsers(object){
    let place = document.getElementById('content')
    
    var elementsToRemove = place.querySelectorAll('div');

    elementsToRemove.forEach(element => {
        element.remove();
    });

    for (let i = 0; i < object.data.length; ) {
        const user = object.data[i];

        const newCard = document.createElement('div');
        newCard.classList.add('card');
        place.appendChild(newCard);

        const newUser = document.createElement('ul')
        newUser.classList.add('list-group');
        newUser.classList.add('list-group-flush');
        newUser.id = `newUser${i}`
        
        newCard.appendChild(newUser);
        
        let userli = document.createElement('li');
        userli.classList.add('list-group-item');
        userli.textContent = 'User:' 
        newUser.appendChild(userli);

        userli.style.backgroundColor = 'rgb(247, 247, 247)'
        userli.style.textAlign = 'left';
                        
        let userid = document.createElement('li');
        userid.classList.add('list-group-item');
        userid.textContent = 'id: ' + user.id

        newUser.appendChild(userid);

        let avatar = document.createElement('li');
        avatar.classList.add('list-group-item');
        avatar.textContent = 'Avatar: ' + user.avatar;

        newUser.appendChild(avatar);

        let email = document.createElement('li');
        email.classList.add('list-group-item');
        email.textContent = 'Email: ' + user.email;


        newUser.appendChild(email);

        let first_name = document.createElement('li');
        first_name.classList.add('list-group-item');
        first_name.textContent = 'First name: ' + user.first_name;

        newUser.appendChild(first_name);

        let last_name = document.createElement('li');
        last_name.classList.add('list-group-item');
        last_name.textContent = 'Last name: ' + user.last_name;

        
        newUser.appendChild(last_name);

        i++;
    }  
}

function fetchReqres(query, url, data){
    console.log('PostData:', JSON.stringify(data))
    const reqres = "https://reqres.in/"
    
    fetch(`${reqres}${url}`, {
        method: `${query}`, // *GET, POST, PUT, DELETE, etc.
        mode: "cors", // no-cors, *cors, same-origin
        cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
        headers: {
          "Content-Type": "application/json"
        },
        redirect: "follow", // manual, *follow, error
        body: JSON.stringify(data), // body data type must match "Content-Type" header
      })
      .then((responsePost) => {
        return responsePost.json(); // parses JSON response into native JavaScript objects;
      })
      .then(postBody => {
        console.log('ResponsePost:', postBody);
      });
      generationUser(data);
}

function selectedpage(id) {
    const selectedelement = document.getElementById(id)
    const allButtons = document.querySelectorAll('.page-item');

    
    allButtons.forEach(button => {
      button.classList.remove('active');
    });

    selectedelement.classList.add('active');   
}

const userDataPUT = {
    data: {
        id: 2,
        email: "janet.weaver@reqres.in",
        first_name: "Julia",
        last_name: "Power",
        avatar: "https://reqres.in/img/faces/2-image.jpg"
    }
};

const userDataPATCH = {
    data: {
        id: 5,
        email: "happy.weaver@reqres.in",
        first_name: "Name",
        last_name: "last",
        avatar: "https://reqres.in/img/faces/2-image.jpg"
    }
};



const usersDataPOST = {
    page:1,
    per_page: 3,
    total: 9,
    total_pages: 3,
        data:[{id:1,
        email:"george.bluth@reqres.in",
        first_name:"George",
        last_name:"Bluth",
        avatar:"https://reqres.in/img/faces/1-image.jpg"},
        {id:2, email:"janet.weaver@reqres.in", first_name:"David", last_name:"Weaver", avatar:"https://reqres.in/img/faces/2-image.jpg"},
        {id:3, email:"un.wong@reqres.in", first_name:"Anna", last_name:"Wong", avatar:"https://reqres.in/img/faces/3-image.jpg"},
        {id:4, email:"gth.holt@reqres.in", first_name:"Eve", last_name:"Holt", avatar:"https://reqres.in/img/faces/4-image.jpg"},
    ]
}

const usersDataPUT = {
    page:1,
        data:[{id:1,
        email:"bruh.bluth@reqres.in",
        first_name:"Bruh",
        last_name:"Bluth",
        avatar:"https://reqres.in/img/faces/1-image.jpg"},
        {id:2, email:"janet.weaver@reqres.in", first_name:"David", last_name:"Weaver", avatar:"https://reqres.in/img/faces/2-image.jpg"},
        {id:3, email:"un.wong@reqres.in", first_name:"Anna", last_name:"Wong", avatar:"https://reqres.in/img/faces/3-image.jpg"},
        {id:4, email:"gth.holt@reqres.in", first_name:"Eve", last_name:"Fun", avatar:"https://reqres.in/img/faces/4-image.jpg"},
        {id:5, email:"sad.morris@reqres.in",first_name:"Denis",last_name:"Morris", avatar:"https://reqres.in/img/faces/5-image.jpg"},
        {id:6, email:"happy.ramos@reqres.in", first_name:"Jonny", last_name:"Happy", avatar:"https://reqres.in/img/faces/6-image.jpg"}
    ]
}

const colorDataPOST400 = {
    page:3,
    per_page: 6,
    total: 5,
    total_pages: 1,
        data:[
        {id:1,name:"color1",year:2000,color:"#rrrrrr",pantone_value:"15-4024"},
        {id:2,name:"color2",year:100,color:"#4564r",pantone_value:"15-4012"},
        {id:3,name:"color3",year:1965,color:"#r54u67",pantone_value:"15-4350"},
        ]
}

const logPOST = {
   
    email: "uk.@gmail.com",
    password: "fefe",
}



function PATCH(url, data){
    fetchReqres("PATCH", url, data)
}


function PUT(url, data){
    fetchReqres("PUT", url, data)
}



