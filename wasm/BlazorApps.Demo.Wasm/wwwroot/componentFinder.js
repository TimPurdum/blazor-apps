export function getComponentName() {
    return document.getElementById('blazor-apps').dataset.component;
}

export function getBlazorComponents() {
    return Array.from(document.querySelectorAll('.blazor-component')).map(a => a.id);
}