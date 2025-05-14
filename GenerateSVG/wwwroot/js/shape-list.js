let selectedSvgPath = null;

document.addEventListener("DOMContentLoaded", () => {
    const svgBoxes = document.querySelectorAll(".svg-box");

    svgBoxes.forEach(box => {
        box.addEventListener("click", () => {
            svgBoxes.forEach(b => b.classList.remove("selected"));
            box.classList.add("selected");
            selectedSvgPath = box.dataset.svg;
        });
    });

    document.getElementById("matrixCreateBtn")?.addEventListener("click", generateMatrix);
    generateMatrix(); // Sayfa açıldığında 1 defa çalıştır
});

function generateMatrix() {
    const size = parseInt(document.getElementById('matrixSizeSelector').value);
    const container = document.getElementById('matrix-area');
    container.innerHTML = '';

    for (let r = 0; r < size; r++) {
        const row = document.createElement('div');
        row.className = 'd-flex gap-2 mb-2';

        for (let c = 0; c < size; c++) {
            const cell = document.createElement('div');
            cell.className = 'matrix-cell border rounded d-flex align-items-center justify-content-center';
            cell.style.width = '60px';
            cell.style.height = '60px';
            cell.style.backgroundColor = '#f8f9fa';
            cell.dataset.row = r;
            cell.dataset.col = c;

            cell.onclick = () => {
                if (!selectedSvgPath) return;
                cell.innerHTML = `<img src="${selectedSvgPath}" width="40" height="40" />`;
            };

            row.appendChild(cell);
        }

        container.appendChild(row);
    }
}
