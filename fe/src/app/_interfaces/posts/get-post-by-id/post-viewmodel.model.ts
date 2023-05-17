export interface PostViewModel {
    id: number;
    title: string;
    details: string;
    kilometersConsumption: number;
    horsePower: number;
    torque: number;
    mortorcycleId: number;  // for getting post has related vehicle 
}