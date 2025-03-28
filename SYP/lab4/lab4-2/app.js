"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function wait() {
    while (true) {
    }
}
let MyPromise = new Promise((res, rej) => {
    res(21);
});
MyPromise.then((value) => { console.log(value); return value; })
    .then((value) => console.log(value * 2));
function GetNum() {
    return __awaiter(this, void 0, void 0, function* () {
        return 21;
    });
}
function UpdateNum() {
    return __awaiter(this, void 0, void 0, function* () {
        let num = yield GetNum();
        console.log(num);
        console.log(num * 2);
    });
}
UpdateNum();
let pr = new Promise((res, rej) => {
    rej('ku');
});
pr
    .then(() => console.log(1))
    .catch(() => console.log(2))
    .catch(() => console.log(3))
    .then(() => console.log(4))
    .then(() => console.log(5));
//# sourceMappingURL=app.js.map