export interface AppTableColumn {
    id: string;
    label: string;
    align?: 'right' | 'left' | 'center';
}

export interface AppTableProps {
    columns: AppTableColumn[];
    rows: Record<string, any>[];
}