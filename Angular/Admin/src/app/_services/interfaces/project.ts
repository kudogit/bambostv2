interface Project {
    id: number,
    title: string,
    investor: string,
    efficiency: string,
    standard: string,
    progress: string,
    description: string,
    projectCategoryId: number,
    projectCategoryName: string
};

interface CreateProject {
    id: number,
    title: string,
    investor: string,
    efficiency: string,
    standard: string,
    progress: string,
    description: string,
    projectCategoryId: number,
    projectCategoryName: string,
    file: any
}