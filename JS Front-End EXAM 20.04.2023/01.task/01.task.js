function solve(input) {
  let horses = input.shift().split('|');

  const commandParser = {
    Retake: retakeHorse,
    Trouble: dropOnePosition,
    Rage: raseTwoPositions,
    Miracle: fromLastToFirst,
  };

  for (const line of input) {
    const [command, ...rest] = line.split(' ');
    if (command === 'Finish') {
      break;
    }
    commandParser[command](...rest.slice(0));
  }

  console.log(horses.join('->'));

  let winner = horses.pop();

  console.log(`The winner is: ${winner}`);

  function retakeHorse(overtakingHorse, overtakenHorse) {
    /*Retake {overtaking-horse} {overtaken-horse} – if the overtaking horse is to the left of the overtaken horse,
  swap the position of the two horses. Then, print the following on the console:
 "{overtaking-horse} retakes {overtaken-horse}."
 */
    let overtakingIndex = horses.indexOf(overtakingHorse);
    let overtakenIndex = horses.indexOf(overtakenHorse);

    if (overtakingIndex < overtakenIndex) {
      horses.splice(overtakenIndex, 1, overtakingHorse);
      horses.splice(overtakingIndex, 1, overtakenHorse);

      console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
    }
  }

  function dropOnePosition(horseName) {
    /*Trouble {horse-name} – the given horse drops by one position, if it's not in the last position already. If the horse does drop, on the console should be printed:
"Trouble for {horse-name} - drops one position."
*/

    let horseIndex = horses.indexOf(horseName);

    if (horseIndex > 0) {
      let behindIndex = horseIndex - 1;

      horses.splice(horseIndex, 1);

      horses.splice(behindIndex, 0, horseName);

      console.log(`Trouble for ${horseName} - drops one position.`);
    }
  }

  function raseTwoPositions(horseName) {
    /*Rage {horse-name} – the given horse rages 2 positions ahead. If the horse is in second position before the command is given, the horse just goes to the first position. If it's already in the first position, it stays in the first position. Then, on the console should be printed:
"{horse-name} rages 2 positions ahead."
*/

    let horseIndex = horses.indexOf(horseName);

    if (horseIndex <= horses.length - 3) {
      let newPosition = horseIndex + 2;
      horses.splice(horseIndex, 1);

      horses.splice(newPosition, 0, horseName);
    } else if (horseIndex === horses.length - 2) {
      const newChamp = horses.splice(horseIndex, 1);

      horses.push(newChamp);
    }
    console.log(`${horseName} rages 2 positions ahead.`);
  }

  function fromLastToFirst() {
    /*Miracle – the horse in the last position gets enormous power and becomes the first. Then, on the console should be printed:
"What a miracle - {horse-name} becomes first."
*/

    let lastOne = horses.shift();

    horses.push(lastOne);

    console.log(`What a miracle - ${lastOne} becomes first.`);
  }
}

solve([
  'Bella|Alexia|Sugar',
  'Retake Alexia Sugar',
  'Rage Bella',
  'Trouble Bella',
  'Finish',
]);

solve([
  'Onyx|Domino|Sugar|Fiona',
  'Trouble Onyx',
  'Retake Onyx Sugar',
  'Rage Domino',
  'Miracle',
  'Finish',
]);

solve([
  'Fancy|Lilly',
  'Retake Lilly Fancy',
  'Trouble Lilly',
  'Trouble Lilly',
  'Finish',
  'Rage Lilly',
]);
