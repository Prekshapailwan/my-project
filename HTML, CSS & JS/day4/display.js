const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
        
document.getElementById('firstname').textContent = urlParams.get('firstname');
document.getElementById('lastname').textContent = urlParams.get('lastname');
document.getElementById('middlename').textContent = urlParams.get('middlename');
document.getElementById('dob').textContent = urlParams.get('dob');
document.getElementById('email').textContent = urlParams.get('email');
document.getElementById('phone').textContent = urlParams.get('phone');
document.getElementById('gender').textContent = urlParams.get('gender');
document.getElementById('bloodgroup').textContent = urlParams.get('bloodgroup');
document.getElementById('comments').textContent = urlParams.get('comments');
        
    