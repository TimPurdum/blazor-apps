window.checkForBlazorComponentId = (componentId) => {
    var component = document.getElementById(componentId);
    if (component != null) {
        var params = JSON.stringify(component.dataset) ?? '';
        console.log('Params: ' + params);
        component.remove();
        return params;
    }
    return null;
}

window.getBlazorParameters = (componentId) => {
    var component = document.getElementById(componentId);
    
}