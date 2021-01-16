export interface Episode {
    description: string;
    macGuffin?: MacGuffin;
    faction?: Faction;
    location?: Location;
    environment?: Environment;
}

export interface ComponentSummary {
    id: string;
    name: string;
    description: string;
}

// tslint:disable-next-line: no-empty-interface
export interface MacGuffin extends ComponentSummary {
}

// tslint:disable-next-line: no-empty-interface
export interface Location extends ComponentSummary {
}

// tslint:disable-next-line: no-empty-interface
export interface Environment extends ComponentSummary {
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
