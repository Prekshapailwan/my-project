const container=document.getElementById("containerid");
const userlable=document.createElement("label");
const userinput=document.createElement("input");
userinput.setAttribute("placeholder","yyy@xx.com");
userlable.innerHTML="Username";
container.appendChild(userlable);
container.appendChild(userinput);

const pswdlable=document.createElement("label");
const pswdinput=document.createElement("input");
pswdinput.setAttribute("placeholder","***********");
pswdinput.setAttribute("type","password");
pswdlable.innerHTML="Password";
container.appendChild(pswdlable);
container.appendChild(pswdinput);


const btn=document.createElement("button");
btn.innerHTML="Login";
container.appendChild(btn);

btn.addEventListener("click",show);
function show(){
    let password=pswdinput.value;
    let username=userinput.value;

    var mailformat = /^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9+_.-]+$/
    if(username.match(mailformat)){    
    }
    else{
        alert("invalid ")
        return false;
    }
    if(password==null||  password<=6){
        alert("invalid");
        return false;
    }

    alert("username "+username+"\n"+"password "+password);
}


