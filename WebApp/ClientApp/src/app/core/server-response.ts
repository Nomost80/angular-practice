export interface ServerResponse<T> {
    readonly message: string;
    readonly data?: T
}
