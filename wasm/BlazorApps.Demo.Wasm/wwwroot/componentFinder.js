export function getComponentName() {
    return document.getElementById('blazor-apps').dataset.component;
}

export function getBlazorComponents() {
    return Array.from(document.querySelectorAll('BlazorComponent')).map(a => a.id);
}