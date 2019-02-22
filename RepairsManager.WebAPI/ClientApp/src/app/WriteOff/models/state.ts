export class State {
    public director: string;
    public organization: string;
    public department: string;
    public commission: Commission;
}

export class Commission {
    public number: string;
    public createDate: Date;
    public chairman: Member;
    public members: Array<Member>;
}

export class Member {
    public name: string;
    public place: string;
}