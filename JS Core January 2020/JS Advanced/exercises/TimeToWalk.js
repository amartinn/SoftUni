function walk(steps,lengthOfFootstep,speed){
let distanceInMeters = steps*lengthOfFootstep;
let speedInSeconds = speed/3.6;
let time =distanceInMeters/speedInSeconds;
let restTime = Math.floor(distanceInMeters/500);

let minutes = Math.floor(time/60);
let seconds = Math.round(time - (minutes*60));
let hours =Math.floor(time/3600);

console.log(`${hours < 10 ? "0" : ""}${hours}:${minutes + restTime < 10 ? "0" : ""}${minutes + restTime}:${seconds < 10 ? "0" : ""}${seconds}`)

}
