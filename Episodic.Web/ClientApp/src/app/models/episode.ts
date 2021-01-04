export interface Episode {
    description: string;
    macGuffin?: MacGuffin;
}

export interface ComponentSummary {
    id: string;
    name: string;
    description: string;
}

// tslint:disable-next-line: no-empty-interface
export interface MacGuffin extends ComponentSummary {
}

export interface CommandResult {
    isSuccess: boolean;
}

export interface EpisodeTemplate extends ComponentSummary {
    descriptionTemplate: string;
    requiredComponents: string[];
}
