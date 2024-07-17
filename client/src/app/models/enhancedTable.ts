export interface Column {
    disablePadding: boolean;
    id: string;
    label: string;
    numeric: boolean;
}

export interface Row {
    [key: string]: number | string;
}

export interface TableHeadProps {
    numSelected: number;
    onRequestSort: (event: React.MouseEvent<unknown>, property: string) => void;
    onSelectAllClick: (event: React.ChangeEvent<HTMLInputElement>) => void;
    order: Order;
    orderBy: string;
    rowCount: number;
    columns: Column[];
}

export interface TableToolbarProps {
    numSelected: number;
    title?: string;
}

export interface TableProps {
    columns: Column[];
    rows: Row[];
}

export type Order = 'asc' | 'desc';