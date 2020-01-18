function solution(input){
    let data = [];
    for (let i = 0; i < input.length; i++) {
        let currentHeroArgs = input[i].split(' / ');

        let heroName = currentHeroArgs[0];
        let heroLevel = +currentHeroArgs[1];
        let heroItems = []
        if(currentHeroArgs.length>2){
            heroItems = currentHeroArgs[2].split(', ');
        }
        let hero = {
            name:heroName,
            level:heroLevel,
            items:heroItems
        };
        data.push(hero);
    }
    console.log(JSON.stringify(data));
}