import { HttpClient } from '@angular/common/http';
import { CommandResult, ComponentSummary } from '../models/episode';



export abstract class ComponentApiService<T> {
    private apiPath: string;
    constructor(private http: HttpClient, baseUrl: string, componentApiPath: string) {
        this.apiPath = baseUrl + componentApiPath;
    }

    getAll$() {
        return this.http.get<ComponentSummary[]>(this.apiPath);
    }

    getById$(id: string) {
        return this.http.get<T>(this.apiPath + '/' + id);
    }

    update$(value: T) {
        return this.http.post<CommandResult>(this.apiPath, value);
    }

    delete$(id: string) {
        return this.http.delete<CommandResult>(this.apiPath + '/' + id);
    }
}
