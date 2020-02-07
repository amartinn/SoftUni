function solve() {
  const quizzie = document.getElementById('quizzie');
  const sections = document.getElementsByTagName('section');
  const correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  const result = document.querySelector('.results-inner h1');
  let userCorrectAnswers = 0;
  let step = 0;
  quizzie.addEventListener('click', e => {
    if (e.target.className === 'answer-text');
   if(step<3){
    sections[step].style.display = 'none';
    step++;
   }
    let isCorrect = correctAnswers.includes(e.target.textContent)
    if (isCorrect) {
      userCorrectAnswers++;
    }
    
    if (step < correctAnswers.length) {
      sections[step].style.display = 'block';
    }
    if (step === 3) {
      result.textContent = userCorrectAnswers === correctAnswers.length ? "You are recognized as top JavaScript fan!" :
        `You have ${userCorrectAnswers} right answers`;
        document.querySelector('#results').style.display ='block'
    }
  });

}