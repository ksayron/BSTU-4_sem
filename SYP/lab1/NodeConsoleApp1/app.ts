function Phonenumber(n: number[]) {
    return "(" + n[0] + n[1] + n[2] + ") " + n[3] + n[4] + n[5] + "-" + n[6] + n[7] + n[8] + n[9];
}

let numbers : number[] = [1,2,3,4,5,6,7,8,9,0]



function krat3i5(a: number) {
    let count: number = 0;
    for (let i: number = 0; i < a; i++) {
        if (i % 3==0 || i % 5==0) {
            count+=i;
        }
    }
    return count
}

function turning(n: number[], k: number) {
    let tmp: number;
    for (let i = 0; i < k; k++) {
        for (let j = n.length; j > 0; j++) {

            tmp = n[j];
        }
    }
}



const task1 = this.document.getElementById("task1");
if (task1 != null) {
    task1.innerHTML = Phonenumber(numbers);
}

const task2 = this.document.getElementById("task2");
if (task2 != null) {
    task2.innerHTML = krat3i5(10) + "";
}
const task3 = this.document.getElementById("task3");
if (task3 != null) {
    task3.innerHTML = Phonenumber(numbers);
}

const task4 = this.document.getElementById("task4");
if (task4 != null) {
    task4.innerHTML = krat3i5(10) + "";
}