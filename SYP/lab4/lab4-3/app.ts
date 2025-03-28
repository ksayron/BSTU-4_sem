function wait(): never {

    while (true) {

    }

}
console.log("\n\n")


let MyPromise = new Promise((res, rej) => {
    res('resolved promise')
})

MyPromise.then((res) => {
    console.log(res)
    return res
})

.then((res1) => {
    console.log(res1)
    wait();
})
