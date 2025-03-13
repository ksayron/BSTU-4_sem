"use strict";
function wait() {
    while (true) {
    }
}
class BaseUser {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}
class Guest extends BaseUser {
    constructor(id, name) {
        super(id, name);
        this.role = "Guest";
        this.permissions = ["View"];
    }
    getRole() {
        return this.role;
    }
}
class User extends BaseUser {
    constructor(id, name) {
        super(id, name);
        this.role = "User";
        this.permissions = ["View", "Post"];
    }
    getRole() {
        return this.role;
    }
}
class Admin extends BaseUser {
    constructor(id, name) {
        super(id, name);
        this.role = "Admin";
        this.permissions = ["View", "Post", "Delete Post", "Manage Users"];
    }
    getRole() {
        return this.role;
    }
}
class HTMLReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        return `<h1>${this.title}</h1><p>${this.content}</p>`;
    }
}
class JSONReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        return { title: this.title, content: this.content };
    }
}
const report1 = new HTMLReport('Weekly report', 'Sales up by 10%');
console.log(report1.generate());
const report2 = new JSONReport('Quarter report', "User base growth by 25%");
console.log(report2.generate());
class CacheClass {
    constructor() {
        this.cache = new Map();
    }
    add(key, value, time) {
        const expirationTime = Date.now() + time;
        this.cache.set(key, { value, expirationTime });
    }
    get(key) {
        const item = this.cache.get(key);
        if (!item || item.expirationTime < Date.now()) {
            this.cache.delete(key);
            return null;
        }
        return item.value;
    }
}
const cache = new CacheClass();
cache.add("price", 100, 2000);
console.log(cache.get("price"));
setTimeout(() => {
    console.log(cache.get("price"));
}, 3000);
function createInstance(cls, ...args) {
    return new cls(...args);
}
const test = createInstance(Admin, 1, "Admin");
console.log(test);
var LogLevel;
(function (LogLevel) {
    LogLevel[LogLevel["INFO"] = 0] = "INFO";
    LogLevel[LogLevel["WARNING"] = 1] = "WARNING";
    LogLevel[LogLevel["ERROR"] = 2] = "ERROR";
})(LogLevel || (LogLevel = {}));
function logEvent(event) {
    let [date, loglevel, info] = event;
    console.log(`${date} [${LogLevel[loglevel]}]: ${info}`);
}
logEvent([new Date(), LogLevel.ERROR, "404 Not Found"]);
var HttpStatus;
(function (HttpStatus) {
    HttpStatus[HttpStatus["ok"] = 200] = "ok";
    HttpStatus[HttpStatus["badRequest"] = 400] = "badRequest";
    HttpStatus[HttpStatus["unauthorized"] = 401] = "unauthorized";
    HttpStatus[HttpStatus["InternalServerError"] = 500] = "InternalServerError";
})(HttpStatus || (HttpStatus = {}));
function success(data) {
    let response = [HttpStatus.ok, data];
    return response;
}
function error(message, status) {
    let response = [status, null, message];
    return response;
}
console.log(success({ user: "User1" }));
console.log(error("Invalid Request", HttpStatus.badRequest));
wait();
//# sourceMappingURL=app.js.map