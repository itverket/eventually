export interface IEvent {
    id?: string;
    name: string;
    location: string;
    description: string;
    starts: Date;
    ends: Date;
    createdInThisSession: boolean;
}
