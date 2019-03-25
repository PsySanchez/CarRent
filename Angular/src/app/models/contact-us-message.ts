export class ContactUsMessageModel {
    public constructor(
        public firstName?: string,
        public lastName?: string,
        public email?: string,
        public phone?: string,
        public message?: string,
        public subject?: string) {}
}
