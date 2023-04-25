window.addEventListener('load', solve);

function solve() {
  //////////////////////////
  const titleInputElement = document.getElementById('task-title');
  let title;
  const categoryInputElement = document.getElementById('task-category');
  let category;
  const contentInputElement = document.getElementById('task-content');
  let content;

  const tasksContainer = document.getElementById('review-list');
  const publishedTasks = document.getElementById('published-list');
  const form = document.querySelector('#newPost > form');

  const publishButton = document.getElementById('publish-btn');
  publishButton.addEventListener('click', publishTask);
  //////////////////////////

  function publishTask(e) {
    if (e) {
      e.preventDefault();
    }
    title = titleInputElement.value;

    category = categoryInputElement.value;

    content = contentInputElement.value;

    if (title && category && content) {
      const newLi = createElement('li', '', '', tasksContainer, ['rpost']);

      const taskCardArticle = createElement('article', '', '', newLi);

      const titleH4 = createElement('h4', `${title}`, '', taskCardArticle);

      const categoryP = createElement(
        'p',
        `Category: ${category}`,
        '',
        taskCardArticle
      );

      const contentP = createElement(
        'p',
        `Content: ${content}`,
        '',
        taskCardArticle
      );

      const editButton = createElement('button', 'Edit', '', newLi, [
        'action-btn',
        'edit',
      ]);
      editButton.addEventListener('click', editTask);

      const postButton = createElement('button', 'Post', '', newLi, [
        'action-btn',
        'post',
      ]);
      postButton.addEventListener('click', postTask);

      form.reset();
    }
  }

  function editTask(e) {
    if (e) {
      e.preventDefault();
    }

    const parent = e.currentTarget.parentNode;

    const article = parent.children[0];

    const oldTitle = article.children[0].textContent;
    titleInputElement.value = oldTitle;
    const oldCategory = article.children[1].textContent.substring(10);
    categoryInputElement.value = oldCategory;
    const oldContent = article.children[2].textContent.substring(9);
    contentInputElement.value = oldContent;

    parent.remove();
  }

  function postTask(e) {
    if (e) {
      e.preventDefault();
    }

    const parent = e.currentTarget.parentNode;
    publishedTasks.appendChild(parent);

    const editBtn = parent.children[1];
    editBtn.remove();
    const postBtn = parent.children[1];
    postBtn.remove();
  }

  function createElement(type, content, id, parentNode, classes, attributes) {
    const newElement = document.createElement(type);

    if (content && type !== 'input') {
      newElement.textContent = content;
    }

    if (content && type === 'input') {
      newElement.value = content;
    }

    if (id) {
      newElement.id = id;
    }

    if (parentNode) {
      parentNode.appendChild(newElement);
    }

    if (classes) {
      newElement.classList.add(...classes);
    }

    if (attributes) {
      for (const key in attributes) {
        newElement.setAttribute(key, attributes[key]);
      }
    }

    return newElement;
  }
}
