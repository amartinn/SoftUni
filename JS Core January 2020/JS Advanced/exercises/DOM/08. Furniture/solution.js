  function solve() {
    const genderateTextArea = document.getElementsByTagName('textarea')[0];
    const buyTextArea = document.getElementsByTagName('textarea')[1];

    const generateButton = document.getElementsByTagName('button')[0];
    const buyButton = document.getElementsByTagName('button')[1];
    const tableBody = document.querySelector('.table tbody');

    document.getElementsByTagName('input')[0].disabled = false;
    generateButton.addEventListener('click', function () {
      let text = genderateTextArea.value;
      if (!text) {
        return;
      }
      let obj = JSON.parse(text)[0];

      if(!obj.hasOwnProperty('img') ||
      !obj.hasOwnProperty('name') ||
      !obj.hasOwnProperty('price') ||
      !obj.hasOwnProperty('decFactor'))
      {
        return;
      }
      let tr = document.createElement('tr');

      let imgtd = document.createElement('td');
      let img = document.createElement('img');
      img.src = obj.img;
      imgtd.appendChild(img);

      let nametd = createElement('p', obj.name);
      let pricetd = createElement('p', obj.price);
      let decorFactortd = createElement('p', obj.decFactor);

      let marktd = document.createElement('td');
      let input = document.createElement('input');
      input.type = 'checkbox';
      marktd.appendChild(input);

      tr.appendChild(imgtd);
      tr.appendChild(nametd);
      tr.appendChild(pricetd);
      tr.appendChild(decorFactortd);
      tr.appendChild(marktd);

      tableBody.appendChild(tr);

      function createElement(type, value) {
        let td = document.createElement('td');
        let element = document.createElement(type);
        element.textContent = value;
        td.appendChild(element);
        return td;
      }

    });

    buyButton.addEventListener('click', function () {
      const checkBoxes = Array.from(document.querySelectorAll('input'));
      let broughtItems = [];
      let totalPrice = 0;
      let decorFactor =0;
      checkBoxes.forEach(box => {
        if (box.checked) {
          let itemName = box.parentElement.parentElement.children[1].children[0].textContent;
          let itemPrice = +box.parentElement.parentElement.children[2].children[0].textContent;
          let itemDecFactor = +box.parentElement.parentElement.children[3].children[0].textContent;
          broughtItems.push(itemName);
          totalPrice+=itemPrice;
          decorFactor+=itemDecFactor;
        }
      })
      if(broughtItems.length===0){
        return;
      }
      let uniqueItems =broughtItems.filter(function(value,index,self){
        return self.indexOf(value) === index;
    }).join(', ');
      buyTextArea.textContent+= `Bought furniture: ${uniqueItems}\n`;
      buyTextArea.textContent+=`Total price: ${totalPrice.toFixed(2)}\n`;
      let avgDecorFactor = decorFactor/broughtItems.length;
      buyTextArea.textContent+=`Average decoration factor: ${avgDecorFactor.toFixed(2)}`;
      this.disabled=true;
    });
  }