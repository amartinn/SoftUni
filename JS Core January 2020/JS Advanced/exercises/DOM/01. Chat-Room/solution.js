function solve() {
  const sendButton = document.getElementById('send');
  const input = document.getElementById('chat_input');
  const messageField = document.getElementById('chat_messages');
  sendButton.addEventListener('click', e => {
    if (input.value === '') {
      return;
    }
    let newDiv = document.createElement('div');
    newDiv.textContent = input.value;
    newDiv.classList.add('message', 'my-message');

    messageField.appendChild(newDiv);
    input.value = '';
  })
}