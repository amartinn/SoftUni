function arena(data) {

    const gladiators = data.reduce((acc, row) => {
        if (row === 'Ave Cesar') {
            return acc;
        }
        if (row.includes('->')) {
            let [gladiator, technique, skill] = row.split(` -> `);
            skill = +skill;
            if (!acc[gladiator]) {
                acc[gladiator] = {
                    [technique]: skill
                };
                return acc;
            }
            if(!acc[gladiator][technique]){
                acc[gladiator][technique] = skill;
                return acc;
            }
            acc[gladiator][technique] +=skill;
        } else {
            let [firstGladiator,secondGladiator] = row.split(` vs `);
            let keys = Object.keys(acc);
            const bothExists = keys.includes(firstGladiator) && keys.includes(secondGladiator);
            if(bothExists){
                let firstGladiatorTechniques = Object.keys(acc[firstGladiator]);
                let secondGladiatorTechniques = Object.keys(acc[secondGladiator]);
                let bothGladiatorTechniques = Array.from(firstGladiatorTechniques);
                bothGladiatorTechniques.push(...secondGladiatorTechniques);
                let duplicateSkills = bothGladiatorTechniques.filter(function(item, pos, self) {
                    return self.indexOf(item) !== pos;
                })
                if(duplicateSkills.length!==0){
                    let firstGladiatorSkillPoints = acc[firstGladiator][duplicateSkills];
                    let secondGladiatorSkillPoints = acc[secondGladiator][duplicateSkills];
                    firstGladiatorSkillPoints>secondGladiatorSkillPoints? delete acc[secondGladiator]:
                    delete acc[firstGladiator];
                    
                }
            }
        }
        return acc;
    }, []);
    let gladiatorFormat = (gladiator,skill)=> `${gladiator}: ${skill} skill`;
    //TODO:Sort 
 }
