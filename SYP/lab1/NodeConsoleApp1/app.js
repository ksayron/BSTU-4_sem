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
function turning(n, k) {
    let tmp;
    for (let i = 0; i < k; i++) {
        tmp = n[0];
        for (let j = 0; j < n.length; j++) {
            if (j != n.length - 1) {
                n[j] = n[j + 1];
            }
            else {
                n[j] = tmp;
            }
            console.log(j);
        }
    }
    return n;
}
function wait() {
    while (true) {
    }
}
function GetMedian(arrnum1, arrnum2) {
    if (arrnum1.length == 0 && arrnum2.length == 0) {
        return null;
    }
    let concatTwoArr = arrnum1.concat(arrnum2);
    concatTwoArr.sort();
    if (concatTwoArr.length % 2 == 0) {
        return (concatTwoArr[(concatTwoArr.length / 2) - 1] + concatTwoArr[concatTwoArr.length / 2]) / 2;
    }
    else {
        return concatTwoArr[Math.floor(concatTwoArr.length / 2)];
    }
}
console.log(Phonenumber(numbers));
console.log(krat3i5(10));
console.log(turning(numbers, 1));
console.log(GetMedian([1, 3], [2, 4]));
console.log(wait());
//# sourceMappingURL=app.js.map