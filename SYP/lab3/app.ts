function wait(): never {

    while (true) {

    }

}

abstract class BaseUser {
    id: number;
    name: string;
    role!: string;
    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }
    abstract getRole(): string
}
class Guest extends BaseUser {
    role = "Guest";
    constructor(id: number, name: string) {
        super(id, name);
    }
    getRole() {
        return this.role;
    }
    permissions: Array<string> = ["View"];
}
class User extends BaseUser {
    role = "User";
    constructor(id: number, name: string) {
        super(id, name);
    }
    getRole() {
        return this.role;
    }
    permissions: Array<string> = ["View", "Post"];

}
class Admin extends BaseUser {
    role = "Admin";
    constructor(id: number, name: string) {
        super(id, name);
    }
    getRole() {
        return this.role;
    }
    permissions: Array<string> = ["View", "Post", "Delete Post", "Manage Users"];
}
interface IReport {
    title: string;
    content: string;
    generate(): string | object;
}
class HTMLReport implements IReport {
    title: string;
    content: string;
    constructor(title: string, content: string) {
        this.title = title;
        this.content = content;
    }
    generate(): string {
        return `<h1>${this.title}</h1><p>${this.content}</p>`
    }
}
class JSONReport implements IReport {
    title: string;
    content: string;
    constructor(title: string, content: string) {
        this.title = title;
        this.content = content;
    }
    generate(): object {
        return { title: this.title, content: this.content };
    }
}
const report1 = new HTMLReport('Weekly report', 'Sales up by 10%');
console.log(report1.generate());
const report2 = new JSONReport('Quarter report', "User base growth by 25%");
console.log(report2.generate());

class CacheClass<T> {
    private cache: Map<string, { value: T; expirationTime: number }>;

    constructor() {
        this.cache = new Map();
    }

    add(key: string, value: T, time: number): void {
        const expirationTime = Date.now() + time;
        this.cache.set(key, { value, expirationTime });
    }

    get(key: string): T | null {
        const item = this.cache.get(key);
        if (!item || item.expirationTime < Date.now()) {
            this.cache.delete(key);
            return null;
        }
        return item.value;
    }


}

const cache = new CacheClass<number>();

cache.add("price", 100, 2000);
console.log(cache.get("price"));

setTimeout(() => {
    console.log(cache.get("price"))
}, 3000)

function createInstance<T>(cls: new (...args: any[]) => T, ...args: any[]): T {
    return new cls(...args);
}
const test = createInstance(Admin, 1, "Admin");
console.log(test);

enum LogLevel {
    INFO, WARNING, ERROR
}
type LogEntry = [Date, LogLevel, string]

function logEvent(event: LogEntry): void {
    let [date, loglevel, info] = event;
    console.log(`${date} [${LogLevel[loglevel]}]: ${info}`);
}

logEvent([new Date(), LogLevel.ERROR, "404 Not Found"])

enum HttpStatus {
    ok = 200,
    badRequest = 400,
    unauthorized = 401,
    InternalServerError = 500
}

type ApiResponse<T> = [status: HttpStatus, data: T | null, error?: string]

function success<T>(data: T): ApiResponse<T> {
    let response: ApiResponse<T> = [HttpStatus.ok, data];
    return response;
}
function error(message: string, status: HttpStatus): ApiResponse<null> {
    let response: ApiResponse<null> = [status, null, message];
    return response;
}

console.log(success({ user: "User1" }));

console.log(error("Invalid Request", HttpStatus.badRequest));

wait();