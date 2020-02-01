//TODO: 40/100

function components(data) {
    let parsedData = data.reduce((acc, compData) => {
        let [systemName, componentName, subComponentName] = compData.split(' | ');
        if (!acc[systemName]) {
            acc[systemName] = {
                [componentName]: [subComponentName]

            };
            return acc;
        }
        if (!acc[systemName][componentName]) {
            acc[systemName][componentName] = [subComponentName];

            return acc;
        }

        acc[systemName][componentName] = [...acc[systemName][componentName], subComponentName];

        return acc;

    }, {});

    let componentFormat = (component) => `|||${component}`;
    let subComponentFormat = (subcomp) => `||||||${subcomp}`;
    let sortedSystems = Object.keys(parsedData).sort((a, b) => {
        if (Object.keys(parsedData[b]).length !== Object.keys(parsedData[a]).length) {
            return 1;
        }
        return a.localeCompare(b);
    });
    sortedSystems.forEach(system => {
        console.log(system);
        Object.keys(parsedData[system]).sort((a, b) => {
            return parsedData[system][a].length - parsedData[system][b].length;
        });
        for (component in parsedData[system]) {
            console.log(componentFormat(component));
            for (subcomponent of parsedData[system][component]) {
                console.log(subComponentFormat(subcomponent));
            }
        }
    });
}