"use strict";
function Phonenumber(n) {
    return "(" + n[0] + n[1] + n[2] + ") " + n[3] + n[4] + n[5] + "-" + n[6] + n[7] + n[8] + n[9];
}
let numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];
function krat3i5(a) {
    let count = 0;
    for (let i = 0; i < a; i++) {
        if (i % 3 == 0 || i % 5 == 0) {
            count += i;
        }
    }
    return count;
}
const task1 = this.document.getElementById("task1");
if (task1 != null) {
    task1.innerHTML = Phonenumber(numbers);
}
const task2 = this.document.getElementById("task2");
if (task2 != null) {
    task2.innerHTML = krat3i5(10) + "";
}
//# sourceMappingURL=app.js.map