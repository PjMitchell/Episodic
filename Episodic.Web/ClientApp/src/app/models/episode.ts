export interface Episode {
    description: string;
    macGuffin?: MacGuffin;
    faction?: Faction;
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

export interface Faction extends ComponentSummary {
    boss: NPC;
}

export interface NPC {
    name: string;
    description: string;
}
