function solve() {
  const searchBtn = document.getElementById('searchBtn');
  const searchField = document.getElementById('searchField');
  const data = document.getElementsByTagName('td');
  let parsedData = [...data].map(x=>x.innerHTML.toLowerCase());
  parsedData.shift();
  let obj = [];
  parsedData.forEach(data => {
     obj.push({data:data,isFound:false})
  });


  searchBtn.addEventListener('click', e=>{
     if(!searchField.value){
         return;
     }
     obj.forEach((d,i)=>{
     
        if(d.isFound===true)
       {
         data[i+1].parentElement.classList.remove('select');
         d.isFound=false;
       }
     });
     
    let keyWord = searchField.value.toLowerCase();
     obj.forEach((d,i)=>{
      if(obj[i].data.includes(keyWord)){
         d.isFound = true;
      
         data[i+1].parentElement.classList.add('select');
      }
     });
     searchField.value='';
  })
}