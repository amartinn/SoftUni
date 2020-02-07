function solve() {
   const productFormat = (name, money) => `Added ${name} for ${money} to the cart.\n`
   const checkOutFormat = (list, totalPrice) => `You bought ${list} for ${totalPrice}.`;

   const checkOutBtn = document.querySelector('.checkout');
   const textArea = document.querySelector('textarea');
   const products = Array.from(document.getElementsByClassName('product'));

   let sum = 0;
   let broughtProducts = [];
   products.forEach(product => {
      let buybtn = product.children.item(2);
      buybtn.addEventListener('click', function () {
         let productPrice = +product.children.item(3).textContent.slice(0);
         let productName = product.children.item(1).children.item(0).textContent;
         broughtProducts.push(productName);
         sum += productPrice;
         textArea.textContent += productFormat(productName, productPrice.toFixed(2));
      });

   });

   checkOutBtn.addEventListener('click', function () {
      let btns = Array.from(document.querySelectorAll('.product button'));
      btns.forEach(btn => {
         btn.disabled = true;
      })

      let output = broughtProducts.filter(function(value,index,self){
         return self.indexOf(value) === index;
      }).join(', ');
      textArea.textContent += checkOutFormat(output, sum.toFixed(2));
      this.disabled=true;
   });
}

