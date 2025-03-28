function wait(): never {

    while (true) {

    }

}

let MyPromise = new Promise<number>((res, rej) => {
    res(21)
})
MyPromise.then((value: number) => { console.log(value); return value; })
    .then((value) => console.log(value * 2))

async function GetNum() {
    return 21;
}

async function UpdateNum() {
    let num = await GetNum();
    console.log(num);
    console.log(num * 2);

}

UpdateNum();
