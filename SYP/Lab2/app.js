"use strict";
function wait() {
    while (true) {
    }
}
const array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
let car = { manufacturer: "manufacturer", model: 'model' };
//
const car1 = { manufacturer: "manufacturer", model: 'model' };
const car2 = { manufacturer: "manufacturer", model: 'model' };
const arrayCars = [{
        cars: [car1, car2]
    }];
let person1 = {
    id: 1,
    name: "Nikolay",
    group: 6,
    marks: [
        { subject: "OOP", mark: 10, done: true },
        { subject: "AISD", mark: 9, done: true }
    ]
};
let person2 = {
    id: 1,
    name: "Nikita",
    group: 10,
    marks: [
        { subject: "SYP", mark: 7, done: true },
        { subject: "KPO", mark: 8, done: true }
    ]
};
let person3 = {
    id: 1,
    name: "Anton",
    group: 6,
    marks: [
        { subject: "KYR", mark: 2, done: false },
        { subject: "OAIP", mark: 3, done: false }
    ]
};
const group1 = {
    students: [],
    studentsFilter: function (group) {
        return this.students.filter(st => st.group === group);
    },
    marksFilter: function (mark) {
        return this.students.filter(st => st.marks.some(m => m.mark >= mark));
    },
    deleteStudent: function (id) {
        let index = this.students.findIndex(st => st.id === id);
        if (index !== -1) {
            this.students.splice(index, 1);
        }
    },
    group: 1,
    mark: 0
};
group1.students.push(person1);
group1.students.push(person2);
group1.students.push(person3);
console.log(group1.marksFilter(8));
group1.deleteStudent(3);
console.log("\n");
group1.students.forEach(std => {
    console.log(std);
});
wait();
//# sourceMappingURL=app.js.map