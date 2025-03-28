"use strict";
function wait() {
    while (true) {
    }
}
let myPromise = new Promise((res, rej) => {
    setTimeout(() => res(Math.random()), 3000);
});
function task3(delay) {
    return myPromise;
}
Promise.all([task3(1000), task3(500), task3(2500)]).then((values) => {
    console.log(values);
    wait();
});
//# sourceMappingURL=app.js.map